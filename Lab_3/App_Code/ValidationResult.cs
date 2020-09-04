using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ValidationResult
/// </summary>
public class ValidationResult
{
    public string Element { get; set; }
    public string Type { get; set; }
    public int Line { get; set; }
    public int Column { get; set; }
    public string Message { get; set; }

    public ValidationResult(string element, string type, int line, int column, string message)
    {
        Element = element;
        Type = type;
        Line = line;
        Column = column;
        Message = message;
    }
}