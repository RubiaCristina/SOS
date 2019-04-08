using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOS_MoradoresDeRua
{
    public static class Menus
    {
        private static Dictionary<MenuEnum, bool> menus = new Dictionary<MenuEnum, bool>();
        static Menus()
        {
            menus.Add(MenuEnum.Inicio, true);
            menus.Add(MenuEnum.Denuncias, false);
            menus.Add(MenuEnum.Desaparecidos, false);
            menus.Add(MenuEnum.Login, false);
            menus.Add(MenuEnum.SituacaoRua, false);
            menus.Add(MenuEnum.Usuarios, false);
        }
        public static string MenuClassInicio => GetClass(MenuEnum.Inicio);
        public static string MenuClassSituacaoRua => GetClass(MenuEnum.SituacaoRua);
        public static string MenuClassDesaparecidos => GetClass(MenuEnum.Desaparecidos);
        public static string MenuClassUsuarios => GetClass(MenuEnum.Usuarios);
        public static string MenuClassDenuncias => GetClass(MenuEnum.Denuncias);
        public static string MenuClassLogin => GetClass(MenuEnum.Login);

        private static string MontaMenuClass(bool item) =>
            item ? "active" : string.Empty;
        public static void ResetMenus()
        {
            var dictTemp = new Dictionary<MenuEnum, bool>(menus);
            foreach (var item in dictTemp)
                menus[item.Key] = false;
        }
        public static string GetClass(MenuEnum menuEnum) =>
            MontaMenuClass(menus[menuEnum]);

        public static void SetActiveMenu(MenuEnum menuEnum)
        {
            ResetMenus();
            menus[menuEnum] = true;
        }
        public enum MenuEnum
        {
            Inicio, SituacaoRua, Desaparecidos, Usuarios, Denuncias, Login
        }
    }
}