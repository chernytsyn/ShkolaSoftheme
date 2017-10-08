﻿using System.ComponentModel.DataAnnotations;

namespace Lection_20_library
{
    class GenreOnlyForViewAttirubute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                if (!value.Equals(BookType.None))
                    return true;
                else
                    this.ErrorMessage = "Книга не может быть без жанра";
            }
            return false;
        }
    }
}