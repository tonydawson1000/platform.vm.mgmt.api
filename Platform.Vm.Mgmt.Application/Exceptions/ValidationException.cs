﻿using FluentValidation.Results;

namespace Platform.Vm.Mgmt.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> ValdationErrors { get; set; }

        public ValidationException(ValidationResult validationResult)
            : base("Validation Errors Occurred.")
        {
            ValdationErrors = new List<string>();

            foreach (var validationError in validationResult.Errors)
            {
                ValdationErrors.Add(validationError.ErrorMessage);
            }
        }
    }
}