<!DOCTYPE html>
<html>
<head>
    <title>@ViewBag.Title</title>
    <link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />
    @Html.DevExpress().GetStyleSheets(
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout},
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.Editors},
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.HtmlEditor},
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.GridView},
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.PivotGrid},
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.Chart},
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.Report},
 New StyleSheet With {.ExtensionSuite = ExtensionSuite.Scheduler},
 New StyleSheet With {.ExtensionSuite = ExtensionSuite.TreeList}
)
    @Html.DevExpress().GetScripts(
    New Script With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout},
    New Script With {.ExtensionSuite = ExtensionSuite.HtmlEditor},
    New Script With {.ExtensionSuite = ExtensionSuite.GridView},
    New Script With {.ExtensionSuite = ExtensionSuite.PivotGrid},
    New Script With {.ExtensionSuite = ExtensionSuite.Editors},
    New Script With {.ExtensionSuite = ExtensionSuite.Chart},
    New Script With {.ExtensionSuite = ExtensionSuite.Report},
 New Script With {.ExtensionSuite = ExtensionSuite.Scheduler},
 New Script With {.ExtensionSuite = ExtensionSuite.TreeList}
)
</head>
<body>
    @RenderBody()
</body>
</html>
