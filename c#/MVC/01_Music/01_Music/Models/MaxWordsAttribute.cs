﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
//自定义数据验证
namespace _01_Music.Models
{
    public class MaxWordsAttribute:ValidationAttribute
    {
        private readonly int _maxWords;

        public MaxWordsAttribute(int maxWords)
            : base("{0} has to many words.")
        {
            _maxWords = maxWords;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value!=null)
            {
                var valueAsString = value.ToString();
                if (valueAsString.Split(' ').Length > _maxWords)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
                return ValidationResult.Success;
            }
            return base.IsValid(value, validationContext);
        }
    
    }
}