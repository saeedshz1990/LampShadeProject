﻿namespace _0_FrameWork.Infrasutructure
{
    public static class Roles
    {
        public const string Administrator = "1";
        public const string SystemUser = "2"; 
        public const string ContentUploader = "3";
        public const string ColleagueUser = "10002";   //باید چک شود 
        public static string GetRoleBy(long id)
        {
            switch (id)
            {
                case 1:
                    return "مدیرسیستم";
                case 3:
                    return "محتوا گذار";
                default:
                    return "";
            }
        }
    }
}
