﻿using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public  async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5077/api/Staff");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffViewModel newStaff)
        {
            var client= _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(newStaff);
            StringContent jsonStaff = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage =await client.PostAsync("http://localhost:5077/api/Staff",jsonStaff);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5077/api/Staff?id={id}");
            if (responseMessage.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5077/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel updateStaff)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateStaff);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"Application/Json");
            var responseMessage = await client.PutAsync("http://localhost:5077/api/Staff/",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {     
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
