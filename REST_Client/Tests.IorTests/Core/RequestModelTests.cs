﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using NUnit.Framework;
using Swensen.Ior.Core;
using Swensen.Utils;
using FluentAssertions;

namespace Tests.IorTests {
    public class RequestModelTests {
        [Test]
        public void TryCreate_url_required() {
            var rvm = new RequestViewModel {
                Body = "",
                Headers = new string[] { },
                Method = HttpMethod.Get.Method,
                Url = "   "
            };

            RequestModel rm = null;
            var errors = RequestModel.TryCreate(rvm, out rm);
            
            errors.Should().HaveCount(1);
            errors[0].Should().Be("Request URL may not be empty");
        }

        [Test]
        public void TryCreate_url_must_be_valid() {
            var rvm = new RequestViewModel {
                Body = "",
                Headers = new string[] { },
                Method = HttpMethod.Get.Method,
                Url = "invali$@#%$@#%%d"
            };

            RequestModel rm = null;
            var errors = RequestModel.TryCreate(rvm, out rm);

            errors.Should().HaveCount(1);
            errors[0].Should().Be("Request URL is invalid");
        }

        [Test]
        public void TryCreate_url_valid() {
            var rvm = new RequestViewModel {
                Body = "",
                Headers = new string[] { },
                Method = HttpMethod.Get.Method,
                Url = "http://www.google.com/"
            };

            RequestModel rm = null;
            var errors = RequestModel.TryCreate(rvm, out rm);

            errors.Should().HaveCount(0);
            rm.Should().NotBeNull();
            rm.Url.ToString().Should().Be("http://www.google.com/");
        }

        [Test]
        public void TryCreate_url_forgiving() {
            var rvm = new RequestViewModel {
                Body = "",
                Headers = new string[] { },
                Method = HttpMethod.Get.Method,
                Url = "www.google.com"
            };

            RequestModel rm = null;
            var errors = RequestModel.TryCreate(rvm, out rm);

            errors.Should().HaveCount(0);
            rm.Should().NotBeNull();
            rm.Url.ToString().Should().Be("http://www.google.com/");
        }

        [Test]
        public void TryCreate_invalid_header_line_format() {
            var rvm = new RequestViewModel {
                Body = "",
                Headers = new string[] { "invalid : format : header" },
                Method = HttpMethod.Get.Method,
                Url = "www.google.com"
            };

            RequestModel rm = null;
            var errors = RequestModel.TryCreate(rvm, out rm);

            errors.Should().HaveCount(1);
            errors[0].Should().StartWith("Invalid header line (format incorrect)");
        }

        [Test]
        public void TryCreate_invalid_header_line_value_blank() {
            var rvm = new RequestViewModel {
                Body = "",
                Headers = new string[] { "invalid : " },
                Method = HttpMethod.Get.Method,
                Url = "www.google.com"
            };

            RequestModel rm = null;
            var errors = RequestModel.TryCreate(rvm, out rm);

            errors.Should().HaveCount(1);
            errors[0].Should().StartWith("Invalid header line (key or value is blank)");
        }

        [Test]
        public void TryCreate_invalid_header_line_key_blank() {
            var rvm = new RequestViewModel {
                Body = "",
                Headers = new string[] { "invalid : " },
                Method = HttpMethod.Get.Method,
                Url = "www.google.com"
            };

            RequestModel rm = null;
            var errors = RequestModel.TryCreate(rvm, out rm);

            errors.Should().HaveCount(1);
            errors[0].Should().StartWith("Invalid header line (key or value is blank)");
        }

        [Test]
        public void TryCreate_invalid_content_header_with_multiple_values() {
            var rvm = new RequestViewModel {
                Body = "",
                Headers = new string[] { "content-type: text/xml; application/xml" },
                Method = HttpMethod.Get.Method,
                Url = "www.google.com"
            };

            RequestModel rm = null;
            var errors = RequestModel.TryCreate(rvm, out rm);

            errors.Should().HaveCount(1);
            errors[0].Should().Match("Invalid header line (*): content-type: text/xml; application/xml");
        }

        [Test]
        public void TryCreate_invalid_request_header_with_invalid_format() {
            var rvm = new RequestViewModel {
                Body = "",
                Headers = new string[] { "From: johny" },
                Method = HttpMethod.Get.Method,
                Url = "www.google.com"
            };

            RequestModel rm = null;
            var errors = RequestModel.TryCreate(rvm, out rm);

            errors.Should().HaveCount(1);
            errors[0].Should().Match("Invalid header line (*): From: johny");
        }

        [Test]
        public void TryCreate_multiple_errors() {
            var rvm = new RequestViewModel {
                Body = "",
                Headers = new string[] { "x : ", "From: johny" },
                Method = HttpMethod.Get.Method,
                Url = "www.google.com"
            };

            RequestModel rm = null;
            var errors = RequestModel.TryCreate(rvm, out rm);

            errors.Should().HaveCount(2);
        }

        [Test]
        public void TryCreate_good_headers() {
            var rvm = new RequestViewModel {
                Body = "",
                Headers = new string[] { "content-type : text/xml", "From: john@smith.com" },
                Method = HttpMethod.Get.Method,
                Url = "www.google.com"
            };

            RequestModel rm = null;
            var errors = RequestModel.TryCreate(rvm, out rm);

            errors.Should().HaveCount(0);
            rm.Should().NotBeNull();
            
            rm.ContentHeaders.Should().HaveCount(1);
            rm.ContentHeaders.First().Key.Should().BeEquivalentTo("content-type");
            rm.ContentHeaders.First().Value.Should().BeEquivalentTo("text/xml");

            rm.RequestHeaders.Should().HaveCount(1);
            rm.RequestHeaders.First().Key.Should().BeEquivalentTo("from");
            rm.RequestHeaders.First().Value.Should().BeEquivalentTo("john@smith.com");
        }

        [Test]
        public void TryCreate_good_headers_ignore_empty_lines() {
            var rvm = new RequestViewModel {
                Body = "",
                Headers = new string[] { "", "content-type : text/xml", "", "From: john@smith.com", "" },
                Method = HttpMethod.Get.Method,
                Url = "www.google.com"
            };

            RequestModel rm = null;
            var errors = RequestModel.TryCreate(rvm, out rm);

            errors.Should().HaveCount(0);
            rm.Should().NotBeNull();

            rm.ContentHeaders.Should().HaveCount(1);
            rm.RequestHeaders.Should().HaveCount(1);
        }

        [Test]
        public void TryCreate_invalid_duplicate_header_keys() {
            var rvm = new RequestViewModel {
                Body = "",
                Headers = new string[] { "Accepts: text/xml", "Accepts: text/html" },
                Method = HttpMethod.Get.Method,
                Url = "www.google.com"
            };

            RequestModel rm = null;
            var errors = RequestModel.TryCreate(rvm, out rm);

            errors.Should().HaveCount(1);
            errors[0].Should().StartWith("Invalid header line (duplicate key, comma-separate multiple values for one key)");
        }
    }
}
