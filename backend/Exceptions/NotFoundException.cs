﻿namespace backend.Services.Exceptions
{
    public abstract class NotFoundException(string message) : Exception(message);
}