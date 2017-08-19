using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM.Splash
{
    class Versiculos
    {

        public string Versos(int valor) 
        {
            Dictionary<int, string> Biblia = new Dictionary<int, string>();
            Biblia.Add(1,"Gal 5:22 : Mas el fruto del Espíritu es amor, gozo, paz, paciencia, amabilidad, bondad, fidelidad");
            Biblia.Add(2,"Juan 10:10 : El ladrón no viene sino para hurtar, matar y destruir; yo he venido para que tengan vida y la tengan en abundancia.");
            Biblia.Add(3,"Hechos 18:10 : Porque yo estoy contigo, y nadie va a hacerte mal, porque yo tengo mucho pueblo en esta ciudad");
            Biblia.Add(4,"Hechos 18:9 : Una noche el Señor le dijo a Pablo en una visión: «No tengas miedo; sigue hablando y no te calles");
            Biblia.Add(5,"Hechos 18:11 : Así que Pablo se quedó un año y seis meses, enseñándoles la palabra de Dios.");
            Biblia.Add(6,"Juan 14:6 : Respondió Jesús: “Yo soy el camino, la verdad y la vida. Nadie viene al Padre, sino por mí.");
            Biblia.Add(7,"Flp 4:7 : Y la paz de Dios, que sobrepasa todo entendimiento, guardará vuestros corazones y vuestros pensamientos en Cristo Jesús.");
            Biblia.Add(8,"Efesios 2:9 : No por obras, para que nadie se gloríe.");
            Biblia.Add(9,"Gal 5:23 : humildad y dominio propio. No hay ley que condene estas cosas.");
            Biblia.Add(10,"Mat 11:28 : “Venid a mí todos los que estáis trabajados y cargados, y yo os haré descansar.");
            return Biblia[valor];
        }
      
    }

}
