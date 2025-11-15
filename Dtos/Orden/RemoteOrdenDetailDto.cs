namespace reseñas.Dtos.Orden
{
    public class RemoteOrdenDetailDto
    {
        public string _id { get; set; } = string.Empty;
        public int num_orden { get; set; }
        public string cod_orden { get; set; } = string.Empty;
        public int usuarioId { get; set; }
        public DireccionEnvioDto? direccionEnvio { get; set; }
        public CostosDto? costos { get; set; }
        public EntregaDto? entrega { get; set; }
        public string metodoPago { get; set; } = string.Empty;
        public string estado { get; set; } = string.Empty;
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaActualizacion { get; set; }
        public List<RemoteOrdenItemDetailDto> items { get; set; } = new();
        public List<HistorialEstadoDto> historialEstados { get; set; } = new();
        public PagoDto? pago { get; set; }
    }

    public class DireccionEnvioDto
    {
        public string nombreCompleto { get; set; } = string.Empty;
        public string telefono { get; set; } = string.Empty;
        public string direccionLinea1 { get; set; } = string.Empty;
        public string direccionLinea2 { get; set; } = string.Empty;
        public string ciudad { get; set; } = string.Empty;
        public string provincia { get; set; } = string.Empty;
        public string codigoPostal { get; set; } = string.Empty;
        public string pais { get; set; } = string.Empty;
    }

    public class CostosDto
    {
        public decimal subtotal { get; set; }
        public decimal impuestos { get; set; }
        public decimal envio { get; set; }
        public decimal total { get; set; }
    }

    public class EntregaDto
    {
        public string tipo { get; set; } = string.Empty;
        public AlmacenDto? almacenOrigen { get; set; }
        public CarrierDto? carrierSeleccionado { get; set; }
        public int direccionEnvioId { get; set; }
    }

    public class AlmacenDto
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string direccion { get; set; } = string.Empty;
        public double latitud { get; set; }
        public double longitud { get; set; }
    }

    public class CarrierDto
    {
        public int carrier_id { get; set; }
        public string carrier_nombre { get; set; } = string.Empty;
        public string carrier_codigo { get; set; } = string.Empty;
        public decimal costo_envio { get; set; }
        public int tiempo_estimado_dias { get; set; }
        public string fecha_entrega_estimada { get; set; } = string.Empty;
        public string cotizacion_id { get; set; } = string.Empty;
    }

    public class HistorialEstadoDto
    {
        public string estadoAnterior { get; set; } = string.Empty;
        public string estadoNuevo { get; set; } = string.Empty;
        public DateTime fechaModificacion { get; set; }
        public string modificadoPor { get; set; } = string.Empty;
        public string motivo { get; set; } = string.Empty;
    }

    public class PagoDto
    {
        public string pago_id { get; set; } = string.Empty;
        public string metodo { get; set; } = string.Empty;
        public string estado { get; set; } = string.Empty;
        public DateTime fecha_pago { get; set; }
        public DatosPagoDto? datosPago { get; set; }
    }

    public class DatosPagoDto
    {
        public string numeroTarjeta { get; set; } = string.Empty;
        public string cvv { get; set; } = string.Empty;
        public string fechaExp { get; set; } = string.Empty;
    }
}
