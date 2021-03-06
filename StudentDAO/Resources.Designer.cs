﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentDAO {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("StudentDAO.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a @studentBirthdate.
        /// </summary>
        internal static string birthDateQueryParam {
            get {
                return ResourceManager.GetString("birthDateQueryParam", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a INSERT INTO dbo.Students (Name, Surname, Birthday) VALUES(@studentName, @studentSurname, @studentBirthdate).
        /// </summary>
        internal static string createQuery {
            get {
                return ResourceManager.GetString("createQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a DELETE FROM dbo.Students.
        /// </summary>
        internal static string deleteAllQuery {
            get {
                return ResourceManager.GetString("deleteAllQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a DELETE FROM dbo.Students WHERE StudentId=@Id.
        /// </summary>
        internal static string deleteQuery {
            get {
                return ResourceManager.GetString("deleteQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a @id.
        /// </summary>
        internal static string idQueryParam {
            get {
                return ResourceManager.GetString("idQueryParam", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a @studentName.
        /// </summary>
        internal static string nameQueryParam {
            get {
                return ResourceManager.GetString("nameQueryParam", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT * FROM dbo.Students.
        /// </summary>
        internal static string selectAllQuery {
            get {
                return ResourceManager.GetString("selectAllQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT * FROM dbo.Students WHERE StudentId=@id.
        /// </summary>
        internal static string selectByIdQuery {
            get {
                return ResourceManager.GetString("selectByIdQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Server=localhost,1433;Database=Vueling;User Id=sa;Password=yourStrong(!)Password;.
        /// </summary>
        internal static string sqlConnection {
            get {
                return ResourceManager.GetString("sqlConnection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a @studentSurname.
        /// </summary>
        internal static string surnameQueryParam {
            get {
                return ResourceManager.GetString("surnameQueryParam", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a UPDATE dbo.Students SET Name=@studentName, Surname=@studentSurname,Birthday=@studentBirthdate WHERE StudentId=@id.
        /// </summary>
        internal static string updateQuery {
            get {
                return ResourceManager.GetString("updateQuery", resourceCulture);
            }
        }
    }
}
