﻿using System;


namespace _1_Wed_API.Models
{
    public class Usuario
    {
        // ATRIBUTOS:
        public int IdUsuario { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string Nombres { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Ciudad { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}