﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LinkupDAO.DAO;
using LinkupEDM.AppModel;

namespace LinkupCN.CN
{
    public class ClientesCN
    {
        private ClientesDAO op = new ClientesDAO();

        public static bool ValidarCorreo(string correo)
        {
            // Patrón de expresión regular para validar una dirección de correo electrónico
            string patron = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";

            // Usar Regex.IsMatch para verificar si la cadena coincide con el patrón
            bool esValido = Regex.IsMatch(correo, patron);

            return esValido;
        }
        public static bool ValidarCedula(string cedula)
        {
            //____________________________Validar Longitud_________________________
            if (string.IsNullOrEmpty(cedula) || cedula.Length != 16)
            {
                return false;
            }

            //_______________________________Validar Solo Numeros_________________________
            if (!cedula.Substring(0, 3).All(char.IsDigit) || !cedula.Substring(4, 6).All(char.IsDigit) || !cedula.Substring(11, 4).All(char.IsDigit))
            {
                return false;
            }

            //________________________VAlidar DIa, mes, año____________________________
            int Validia = Convert.ToInt32(cedula.Substring(4, 2));

            if (Validia > 31 || Validia < 1)
            {
                return false;
            }

            int ValiMes = Convert.ToInt32(cedula.Substring(6, 2));

            if (ValiMes < 1 || ValiMes > 12)
            {
                return false;
            }

            //________________________Ultima Letra_______________________________________
            if (!char.IsLetter(cedula.Last()))
            {
                return false;
            }

            //________________________Validar Guiones__________________________________________
            if (!System.Text.RegularExpressions.Regex.IsMatch(cedula.Substring(3, 1), "[-]") || !System.Text.RegularExpressions.Regex.IsMatch(cedula.Substring(10, 1), "[-]"))
            {
                return false;
            }

            // Si todos los validadores pasan, entonces la cédula es válida.
            return true;
        }

    public List<Clientes> Listar()
        {
            return op.Listar();
        }

        public int Agregar(Clientes obj,out string mensaje)
        {

            mensaje = string.Empty;
         
           
            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                mensaje = "El Nombre del cliente es obligatorio";
            }
            if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                mensaje = "Los apellidos del cliente es obligatorio";
            }
            if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
            {
                mensaje = "La Direccion del cliente es obligatorio";
            }
            if (string.IsNullOrEmpty(obj.Cedula) || string.IsNullOrWhiteSpace(obj.Cedula))
            {
                mensaje = "La Cedula del cliente es obligatoria";
                if (!ValidarCedula(obj.Cedula))
                {
                    mensaje = "La Cédula del cliente es inválida";
                }
            }
           
            if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                mensaje = "El correo del cliente es obligatorio";
            }
            else if (op.ClienteYaExiste(obj.Cedula, obj.Correo, out mensaje))
            {
                mensaje = "Ya existe en la base de datos";
            }
            else
            {
                if (!ValidarCorreo(obj.Correo))
                {
                    mensaje = "El correo electrónico es inválido";
                }
            }

            if (string.IsNullOrEmpty(obj.Clave) || string.IsNullOrWhiteSpace(obj.Clave))
            {
                mensaje = "La clave del cliente es obligatoria";
            }
            if (obj.Telefono==0)
            {
                mensaje = "El telefono del cliente es obligatorio";
            }
            if (string.IsNullOrEmpty(mensaje))
            {
                string clave = obj.Clave;

                string asunto = "Creación de cuenta";
                string mensaje_correo = "<h3>Su cuenta ha sido creada con éxito</h3></br><p> su contraseña es: ¡clave!</p>";
                mensaje_correo = mensaje_correo.Replace("¡clave!", clave);


                bool respuesta = RecursosCN.EnviarCorreo(obj.Correo, asunto, mensaje_correo);

                if (respuesta)
                {
                    obj.Clave = RecursosCN.ConvertirSha256(clave);
                    return op.Agregar(obj, out mensaje);
                }
                else
                {
                    mensaje = "No se pudo enviar el correo";
                    return 0;
                }
            }
            else
            {
                return 0;
            }


        }
        public bool Editar(Clientes obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (!ValidarCedula(obj.Cedula))
            {
                mensaje = "La Cédula del cliente es inválida";
            }
            if (!ValidarCorreo(obj.Correo))
            {
                mensaje = "El correo electronico es inválido";
            }
            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                mensaje = "El Nombre del cliente es obligatorio";
            }
            if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                mensaje = "Los apellidos del cliente es obligatorio";
            }
            if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
            {
                mensaje = "La Direccion del cliente es obligatorio";
            }
            if (string.IsNullOrEmpty(obj.Cedula) || string.IsNullOrWhiteSpace(obj.Cedula))
            {
                mensaje = "La Cedula del cliente es obligatoria";
            }
            if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                mensaje = "El correo del cliente es obligatorio";
            }
            if (string.IsNullOrEmpty(obj.Clave) || string.IsNullOrWhiteSpace(obj.Clave))
            {
                mensaje = "La clave del cliente es obligatoria";
            }
            if (obj.Telefono == 0)
            {
                mensaje = "El telefono del cliente es obligatorio";
                
            }
            if (string.IsNullOrEmpty(mensaje))
            {
                return op.Modificar(obj, out mensaje);
            }
            else
            {
                return false;
            }
        }
        public bool Eliminar(int id, out string Mensaje)
        {
            var cliente = new Clientes { Id = id };
            return op.Eliminar(id, out Mensaje);
        }
    }
}
