using apı.Model;
using apı.Model.Request;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;


namespace apı.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class WeatherForecastController : ControllerBase
    {
        [HttpPost]
        public void Ekle([FromBody] StudentRequest gelenOgrenci)
        {
            Student student = new Student();
            Mapper(gelenOgrenci, student);
            student.Id = 10;
            student.OgrenciSiraNo = 100;
            student.Ekle();


        }
        public static T2 Mapper<T1, T2>(T1 fromModel, T2 toModel) where T1 : class, new() where T2 : class
        {
            PropertyInfo[] fromModelProperties = typeof(T1).GetProperties();
            PropertyInfo[] toModelProperties = typeof(T2).GetProperties();

            foreach (var prop in fromModelProperties)
            {
                if (toModelProperties.Any(x => x.Name == prop.Name))
                {
                    //from modelden  ilgili property nin değeri bulundu
                   PropertyInfo? property= fromModel.GetType().GetProperty(prop.Name);
                    if(property !=null)
                    {
                        var deger = property.GetValue(fromModel, null);
                        //Bulunan bu değer to modelin içerisinde ilgili property e set edilecek.

                        PropertyInfo? propertytarget = toModel.GetType().GetProperty(prop.Name);
                        if (propertytarget != null)
                        {
                            propertytarget.SetValue(toModel, deger);



                        }



                    }

                }



            }
            return toModel;
        }

    }



}