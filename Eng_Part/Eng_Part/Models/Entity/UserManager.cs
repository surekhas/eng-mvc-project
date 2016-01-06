using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eng_Part.Models.Database;
using Eng_Part.Models.ViewModels;


namespace Eng_Part.Models.Entity
{
    public class UserManager
    {

        public void AddUserAccount(UserSignUpView user)
        {

            using (Eng_PartEntities db = new Eng_PartEntities())
            {

                SYSUser SU = new SYSUser();
                SU.LoginName = user.LoginName;
                SU.PasswordEncryptedText = user.Password;
                SU.RowCreatedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                SU.RowModifiedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1; ;
                SU.RowCreatedDateTime = DateTime.Now;
                SU.RowMOdifiedDateTime = DateTime.Now;

                db.SYSUsers.Add(SU);
                db.SaveChanges();

                SYSUserProfile SUP = new SYSUserProfile();
                SUP.SYSUserID = SU.SYSUserID;
                SUP.FirstName = user.FirstName;
                SUP.LastName = user.LastName;
                SUP.Gender = user.Gender;
                SUP.RowCreatedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                SUP.RowModifiedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                SUP.RowCreatedDateTime = DateTime.Now;
                SUP.RowModifiedDateTime = DateTime.Now;

                db.SYSUserProfiles.Add(SUP);
                db.SaveChanges();


                if (user.LOOKUPRoleID > 0)
                {
                    SYSUserRole SUR = new SYSUserRole();
                    SUR.LOOKUPRoleID = user.LOOKUPRoleID;
                    SUR.SYSUserID = user.SYSUserID;
                    SUR.IsActive = true;
                    SUR.RowCreatedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                    SUR.RowModifiedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                    SUR.RowCreatedDateTime = DateTime.Now;
                    SUR.RowModifiedDateTime = DateTime.Now;

                    db.SYSUserRoles.Add(SUR);
                    db.SaveChanges();
                }
            }
        }

        public bool IsLoginNameExist(string loginName)
        {
            using (Eng_PartEntities db = new Eng_PartEntities())
            {
                return db.SYSUsers.Where(o => o.LoginName.Equals(loginName)).Any();
            }
        }

        public string GetUserPassword(string loginName)
        {
            using (Eng_PartEntities db = new Eng_PartEntities())
            {
                var user = db.SYSUsers.Where(o => o.LoginName.ToLower().Equals(loginName));
                if (user.Any())
                    return user.FirstOrDefault().PasswordEncryptedText;
                else
                    return string.Empty;
            }
        }

        //public bool UserIsInRole(string loginName, string roleName)
        //{
        //    using (Eng_PartEntities db = new Eng_PartEntities())
        //    {

        //        SYSUsers SU = db.SYSUsers.Where(o => o.LoginName.ToLower().Equals(loginName)).FirstOrDefault();

        //        if (SU != null)
        //        {
        //            //var roles = from q in db.UserRoles
        //            //            join r in db.SysUserRoles on q.RoleID equals r.RoleID
        //            //            where q.RoleName.Equals(roleName) && r.UserID.Equals(SU.UserID)
        //            //            select q.RoleName;


        //            var roles = from q in db.UserRoles
        //                        join r in db.SysUserRoles on q.RoleID equals r.RoleID
        //                        where q.RoleName.Equals(roleName) && r.UserID.Equals(2)
        //                        select q.RoleName;

        //            if (roles != null)
        //            {
        //                return roles.Any();
        //            }

        //        }

        //        return true;

        //    }



        //}// function ends 

        public bool IsUserInRole(string loginName, string roleName)
        {
            using (Eng_PartEntities db = new Eng_PartEntities())
            {
                SYSUser SU = db.SYSUsers.Where(o => o.LoginName.ToLower().Equals(loginName)).FirstOrDefault();
                if (SU != null)
                {
                    var roles = from q in db.SYSUserRoles
                                join r in db.LOOKUPRoles on q.LOOKUPRoleID equals r.LOOKUPRoleID
                                where r.RoleName.Equals(roleName) && q.SYSUserID.Equals(SU.SYSUserID)
                                select r.RoleName;

                    if (roles != null)
                    {
                        return roles.Any();
                    }
                }

                return false;
            }
        }


    }

    public class PartManager
    {

        public void AddPart(EngParts part)
        {

            using (Eng_PartEntities db = new Eng_PartEntities())
            {

                ModulePart mp = new ModulePart();

                mp.PartName = part.PartName;
                mp.PartDesc = part.PartDesc;
                mp.PartDimension = part.PartDimension;
                mp.PartMetal = part.PartMetal;
                mp.PartCDate = DateTime.Now;
                mp.PartMDate = DateTime.Now;

                db.ModuleParts.Add(mp);
                db.SaveChanges();

            }

        }

        public List<EngParts> ListPart() {
            List<EngParts> p = new List<EngParts>();


            return p;
        
        }


    }


}