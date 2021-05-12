using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FreeCourse.Shared.Dtos
{
    public class ResponseDto<T>
    {
        //Dışarıdan set edilmesini istemediğimiz için "private set" yaptık zaten nesne örneği metodda dönüyor

        //Bu tür metodları "Static Factory Metod" denir. metodlarla birlikte geriye yeni bir nesne dönüyorsak bu kullanılır
        public T Data { get; private set; }

        [JsonIgnore]
        public int StatusCode { get; private set; } //postmande çıkan status code 

        [JsonIgnore]
        public bool IsSuccessful { get; private set; } //başarılı mı değil mi

        //hataları almak için tanımladık
        public List<string> Errors { get; set; }

        //başarılı ve data alır
        public static ResponseDto<T> Success(T data, int statusCode)
        {
            return new ResponseDto<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }

        //başarılı ama data almayabilir
        public static ResponseDto<T> Success(int statusCode)
        {
            return new ResponseDto<T> { Data = default(T), StatusCode = statusCode, IsSuccessful = true };
        }

        //birden çok hata için
        public static ResponseDto<T> Fail (List<string> errors, int statusCode)
        {
            return new ResponseDto<T>
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }

        //tek bir hata için
        public static ResponseDto<T> Fail(string errors, int statusCode)
        {
            return new ResponseDto<T>
            {
                Errors = new List<string>() { errors},
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }
        
    }
}
