﻿@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
</head>
<body>
   <div>
      <p>This sample shows how to control IIS by two different ways. <br />
          You can check the changes in IIS.
      </p>
     @Html.ActionLink("Show Details", "ShowDetails")
       
    </div>
</body>
</html>