﻿namespace CadastroPostoVacina.Communication.Responses;
public class ResponseErrorJson
{
    public string Message { get; set; } = string.Empty;

    public ResponseErrorJson(string message)
    {
        Message = message;
    }
}
