﻿using Microsoft.AspNetCore.Components.Web;

namespace WebUI.Utilities;

public  static class Helper
{
    public static bool DeleteFile(params string [] path)
    {
        var resultPath =String.Empty;

        foreach (var item in path)
        {
            resultPath = Path.Combine(resultPath, item);
        }
        if (File.Exists(resultPath))
        {
           File.Delete(resultPath);
            return true;

        }
        return false;
    }
}
