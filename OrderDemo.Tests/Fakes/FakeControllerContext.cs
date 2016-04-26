﻿using Moq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OrderDemo.Tests.Fakes
{
	public class FakeControllerContext : ControllerContext
	{
		HttpContextBase _context = new FakeHttpContext();

		public override HttpContextBase HttpContext {
			get {
				return _context;
			}

			set {
				_context = value;
			}
		}
	}

	public class FakeHttpContext : HttpContextBase
	{
		HttpRequestBase _request = new FakeHttpRequest();

		public override HttpRequestBase Request {
			get {
				return _request;
			}
		}
	}

	public class FakeHttpRequest : HttpRequestBase
	{
		public override string this[string key] {
			get {
				return null;
			}
		}

		public override NameValueCollection Headers {
			get {
				return new NameValueCollection();
			}
		}
	}
}
