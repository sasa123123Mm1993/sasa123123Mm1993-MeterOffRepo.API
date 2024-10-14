using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Base_Response.Providers
{
    public static class Success
    {
        public static string Code = "200";
        public static string Status = "Success";
        public static string messageEn = "Success Get Data";
        public static string messageAr = "تم تحميل البيانات بنجاح";
    }

    public static class SaveSuccess
    {
        public static string Code = "200";
        public static string Status = "Success";
        public static string messageEn = "Informaion Is Saved";
        public static string messageAr = "تم الحفظ بنجاح";
    }

    public static class Updated
    {
        public static string Code = "200";
        public static string Status = "Success";
        public static string messageEn = "Informaion Is Updated";
        public static string messageAr = "تم التعديل بنجاح";
    }

    public static class DeleteSuccess
    {
        public static string Code = "201";
        public static string Status = "Success";
        public static string messageEn = "Informaion Is Deleted";
        public static string messageAr = "تم المسح بنجاح";
    }

    public static class Failed
    {
        public static string Code = "5001";
        public static string Status = "fail";
        public static string messageEn = "Something Wrong!";
        public static string messageAr = " حدث خطأ أثناء تحميل البيانات";
    }

    public static class Added
    {
        public static string Code = "200";
        public static string Status = "Success";
        public static string messageEn = "Data Added Successfully";
        public static string messageAr = "تم اضافة البيانات بنجاح";
    }

    public static class Empty
    {
        public static string Code = "5002";
        public static string Status = "empty";
        public static string messageEn = "List is Empty";
        public static string messageAr = "القائمة فارغة";
    }

    public class EmptyMember
    {
        public static string Code = "5003";
        public static string Status = "empty";
        public static string messageEn = "Data Not Found";
        public static string messageAr = "لا توجد بيانات";
    }


    public class GeneralException
    {
        public static string Code = "8000";
        public static string Status = "error";
        public static string messageEn = "General Fault";
        public static string messageAr = "خطأ عام";
    }
}
