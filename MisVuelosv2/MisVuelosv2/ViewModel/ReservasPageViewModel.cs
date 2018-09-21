﻿using MisVuelosv2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MisVuelosv2.ViewModel
{
    public class ReservasPageViewModel : ContentPage
    {

        public ReservasPageViewModel(int cedula = 0, string reserva = "")
        {
            CargarReservas(cedula, reserva);
        }

        public ObservableCollection<Datos_reserva> ListaDatos_Reserva
        {
            get;
            set;
        }

        private void CargarReservas(int nro_ci = 0, string cod_reserva = "")
        {
            try
            {
                Datos_reserva dr;
                Vuelos vuelo;
                Clientes cliente;

                List<Reservaciones> Lista_reservaciones = new List<Reservaciones>();
                //ListaDatos_Reserva.Clear();
                ListaDatos_Reserva = new ObservableCollection<Datos_reserva>();
                if (cod_reserva.Trim().Length > 0 && cod_reserva != null)
                {
                    Reservaciones reservacion = App.Database.GetReservacionByReservaAsync(cod_reserva.Trim()).Result.FirstOrDefault();
                    vuelo = App.Database.GetVueloAsync(reservacion.id_vuelo).Result;
                    cliente = App.Database.GetClientesAsync().Result.Where(x => x.ID == reservacion.id_cliente).FirstOrDefault();

                    dr = new Datos_reserva
                    {
                        reserva = reservacion.reserva,
                        id_vuelo = reservacion.id_vuelo,
                        id_cliente = reservacion.id_cliente,
                        asientos = reservacion.asientos,
                        pago = reservacion.pago,
                        fecha = reservacion.fecha,
                        aerolinea = vuelo.aerolinea,
                        origen = vuelo.origen,
                        destino = vuelo.destino,
                        fecha_vuelo = vuelo.fecha,
                        Nombre = cliente.Nombre,
                        Cedula = cliente.Cedula,
                        Edad = cliente.Edad
                    };

                    ListaDatos_Reserva.Add(dr);
                }
                else
                {
                    var x_id_cliente = App.Database.GetClientesAsync().Result.Where(x => x.Cedula == nro_ci).Select(x => x.ID).FirstOrDefault();

                    Lista_reservaciones = App.Database.GetReservacionByCIAsync(x_id_cliente).Result.ToList();

                    //Lista_reservaciones = App.Database.GetReservacionAsync(x_id_cliente, "").Result.ToList();
                    cliente = App.Database.GetClientesAsync().Result.Where(x => x.ID == x_id_cliente).FirstOrDefault();

                    foreach (var item in Lista_reservaciones)
                    {
                        vuelo = App.Database.GetVueloAsync(item.id_vuelo).Result;
                        dr = new Datos_reserva
                        {
                            reserva = item.reserva,
                            id_vuelo = item.id_vuelo,
                            id_cliente = item.id_cliente,
                            asientos = item.asientos,
                            pago = item.pago,
                            fecha = item.fecha,
                            aerolinea = vuelo.aerolinea,
                            origen = vuelo.origen,
                            destino = vuelo.destino,
                            fecha_vuelo = vuelo.fecha,
                            Nombre = cliente.Nombre,
                            Cedula = cliente.Cedula,
                            Edad = cliente.Edad
                        };

                        ListaDatos_Reserva.Add(dr);
                    }

                    bool ExisteCliente = App.Database.GetClientesAsync().Result.Where(x => x.Cedula == Convert.ToInt32(nro_ci)).ToList().Count > 0 ? true : false;

                    if (ExisteCliente == true)
                    {
                        int _id_cliente = App.Database.GetClientesAsync().Result.Where(x => x.Cedula == Convert.ToInt32(nro_ci)).FirstOrDefault().ID;
                        var vuelos = App.Database.GetVuelosAsync().Result.ToList();
                    }
                    else
                    {
                        DisplayAlert("Error", "El cliente no existe", "OK");
                    }
                }
            }
            catch (Exception ex)
            {

                DisplayAlert("Error", ex.Message, "OK");
            }

        }

    }
    
}
