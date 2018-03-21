using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Connector;
using Service.Model;
using Newtonsoft.Json.Linq;


namespace Service.Controllers
{
    
    public class ValuesController : Controller
    {
        // เรียก Member
        [Route("api/GetMember")]
        [HttpGet]
        public IEnumerable<Member> Get()
        {
             Mysql mysqlGet = new Mysql();
         
            return mysqlGet.UserList();
        }
        // เรียก History
        [Route("api/GetHistory")]
        [HttpGet]
        public IEnumerable<History> GetHistory(){
             Mysql mysqlGet = new Mysql();
             return mysqlGet.HistortList();
          
        }
         
        // สมัครสมาชิก
        // [Route("api/CreateMember/{id}/{firstname}/{lastname}/{card}/{tel}/{address}/{pre}/{img}")]
        // [HttpPost]
        // public string CreateMember(string id,string firstname,string lastname,string card,string tel,string address,string pre,string img )
        // {
            
        //     Mysql mysqlGet = new Mysql();
        //     return mysqlGet.Register(id,firstname,lastname,card,tel,address,pre,img);
        // }
        // ลบสมาชิก
        [Route("api/DeleteMember/{id}")]
        [HttpGet]
         public string DeleteMember(int id)
        {
            
            Mysql mysqlGet = new Mysql();
            return mysqlGet.DeleteMember(id);
        }
        //แก้ไขสมาชิก
        [Route("api/EditMember/{id}/{emId}/{firstname}/{lastname}/{card}/{tel}/{address}")]
        [HttpGet]
        public string EditMember(int id,string emId,string firstname,string lastname,string card,string tel,string address )
        {
             Mysql mysqlGet = new Mysql();
            return mysqlGet.EditMember(id,emId,firstname,lastname,card,tel,address);
           
        }
        [Route("api/SaveHistory/{EmId}/{Name}/{Surname}/{Tel}/{Date}")]
        [HttpGet]
        public string SaveHistory(int EmId,string Name,string Surname,string Tel,string Date){
           
               Mysql mysqlGet = new Mysql();
             return mysqlGet.SaveHistory(EmId,Name,Surname,Tel,Date);
        }
         // POST api/values
        [Route("api/Register")]
        [HttpPost]
        public string  Register(Member Member)
        {
            Console.WriteLine(Member.Mem_em_id);
            Mysql mysqlGet = new Mysql();
            return mysqlGet.Register(Member.Mem_em_id,Member.Mem_firstname,Member.Mem_lastname,Member.Mem_id_card,Member.Mem_tel,Member.Mem_address,Member.Mem_images);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
