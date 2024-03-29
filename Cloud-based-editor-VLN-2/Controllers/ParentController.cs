﻿using System.IO;
using System.Web.Mvc;

namespace Cloud_based_editor_VLN_2.Controllers {
	public class ParentController : Controller {
		public string RenderRazorViewToString(string viewName, object model) {
			ViewData.Model = model;

			using (var sw = new StringWriter()) {

				var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
				var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
				viewResult.View.Render(viewContext, sw);
				viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
				return sw.GetStringBuilder().ToString();
			}
		}
	}
}