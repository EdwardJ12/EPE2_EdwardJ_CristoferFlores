using Microsoft.AspNetCore.Mvc;

public class FacturacionController : ControllerBase{

    public Empresa[] datos = new Empresa[]{

        new Empresa {Id=1, nom_cliente = "Alberto", ape_cliente = "Gonzalez",Edad = 51,rut_cliente = "10.726.736-k", nom_empresa = "Amazon", rut_empresa = "70.333.444-7", giro_empresa="Venta de Artilugios",total_venta=300,monto_ventas=4000000,iva_monto=7600000, utilidades_montoMes= 3600000  },
        new Empresa {Id=2, nom_cliente = "Raul", ape_cliente = "Estrada",Edad = 34,rut_cliente = "13.234.856-8", nom_empresa = "Argos", rut_empresa = "45.345.345-3", giro_empresa="Caramelos",total_venta=230,monto_ventas=2300000,iva_monto=437000, utilidades_montoMes=  1863000  },
        new Empresa {Id=3, nom_cliente = "Cristobal", ape_cliente = "Castillo",Edad = 30,rut_cliente = "13.456.725-8", nom_empresa = "3M", rut_empresa = "67.687.232-6", giro_empresa="Limpieza y cuidados",total_venta=270,monto_ventas=3000000,iva_monto=570000, utilidades_montoMes=  2430000  }

    };

   
   [HttpGet]
[Route("Empresa")]

public IActionResult ListarDatos(){
    if (datos != null){

         for(int i = 0; i < datos.Length; i++){
            Console.WriteLine("con exito", datos[i]);
    }
            
    return StatusCode(200, datos);
} else {
            Console.WriteLine("no hay datos");
    return StatusCode(404);        
}
}

[HttpGet]
    [Route("Empresa/{Id}")]

    public IActionResult ListarDatosId(int id){


        //creamos elemento de control para recorrer el arreglo
        if (id > 0 && id <= datos.Length){

            //imprimimos en consola que se encontro la persona
            Console.WriteLine("Se encontro la Empresa");

            //imprimimos el status code 200 que es correcto
            return StatusCode(200, datos[id-1]);


        }else{

            //imprimimos en consola que no se encontro la persona
            Console.WriteLine("Datos No encontrados");
            return StatusCode(404);

        }

    }

      [HttpPost]
    [Route("Empresa")]
    public IActionResult Empresa([FromBody] Empresa datos){


        //generamos un elemento de control para el ingreso de nueva persona
        if(datos != null){

            //imprimimos en consola que se creo la persona
            Console.WriteLine("Se creo la empresa");
            return StatusCode(201, datos);
            
            }else{

                //imprimimos en consola que no se creo la persona
                Console.WriteLine("No se pudo crear la empresa");
                return StatusCode(404);
                
                }

    }

     [HttpPut]
[Route("Empresa/{Id}")]
public IActionResult EditarEmpresa(int id, [FromBody] Empresa newDatos)
{
    if (id > 0 && id <= datos.Length)
    {
        // Procedemos a la edición de la empresa
        datos[id - 1].Id = newDatos.Id;
        datos[id - 1].nom_cliente = newDatos.nom_cliente;
        datos[id - 1].ape_cliente = newDatos.ape_cliente;
        datos[id - 1].Edad = newDatos.Edad;
        datos[id - 1].rut_cliente = newDatos.rut_cliente;
        datos[id - 1].nom_empresa = newDatos.nom_empresa;
        datos[id - 1].rut_empresa = newDatos.rut_empresa;
        datos[id - 1].giro_empresa = newDatos.giro_empresa;

        // Devolvemos el elemento modificado con el status code 200
        return StatusCode(200, datos[id - 1]);
    }
    else
    {
        // Imprimimos en consola que no se encontró la empresa
        Console.WriteLine("Empresa No encontrada");
        return StatusCode(404);
    }
}


    
 [HttpDelete]
    [Route("Empresa/{Id}")]

    public IActionResult BorrarDatos(int id){

        //creamos elemento de control para recorrer el arreglo
        if (id > 0 && id <= datos.Length){

            //procedemos a la eliminacion de la persona
            datos[id-1] = null;
            
            //imprimimos el status code 200 que es correcto
            return StatusCode(200, datos);
            
         
            }else{

                //imprimimos en consola que no se encontro la persona
                Console.WriteLine("Persona No encontrada");
                return StatusCode(404);
                
                }

    }




}