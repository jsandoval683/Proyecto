using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using WSServit.Helper;
using WSServit.Models;
using WSServit.Models.Entities;
using WSServit.Models.Response;
using WSServit.ViewModels;

namespace WSServit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountsController : Controller
    {
        private readonly ServitDataBaseContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AccountsController(UserManager<AppUser> userManager, IMapper mapper, ServitDataBaseContext appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<AppUser>(model);

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(ErrorHelper.AddErrorsToModelState(result, ModelState));

            await _appDbContext.Customers.AddAsync(new Customer { IdentityId = userIdentity.Id, Location = model.Location });
            await _appDbContext.SaveChangesAsync();

            return new OkObjectResult("Account created");
        }
    }

    //public class AccountsController : ControllerBase
    //{
    //    private readonly ServitDataBaseContext _appDbContext;
    //    private readonly UserManager<AppUser> _userManager;

    //    public AccountsController(UserManager<AppUser> userManager, ServitDataBaseContext appDbContext)
    //    {
    //        _userManager = userManager;
    //        _appDbContext = appDbContext;
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> Post([FromBody]RegistrationViewModel source)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        var config = new MapperConfiguration(cfg =>
    //        {
    //            cfg.CreateMap<RegistrationViewModel, AppUser>();
    //        });

    //        IMapper iMapper = config.CreateMapper();

    //        var userIdentity = iMapper.Map<RegistrationViewModel, AppUser>(source);

    //        userIdentity.UserName = source.Email;
    //        var result = await _userManager.CreateAsync(userIdentity, source.Password);

    //        if (!result.Succeeded) return new BadRequestObjectResult(ErrorHelper.AddErrorsToModelState(result, ModelState));

    //        await _appDbContext.Customers.AddAsync(new Customer { IdentityId = userIdentity.Id, Location = source.Location });
    //        await _appDbContext.SaveChangesAsync();

    //        return new OkObjectResult("Account succesfully created!");
    //    }
    //}
}