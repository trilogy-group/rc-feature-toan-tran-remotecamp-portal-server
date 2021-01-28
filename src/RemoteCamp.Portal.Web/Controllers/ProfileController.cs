using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Atlassian.Jira;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Services;
using RemoteCamp.Portal.Core.Infrastructure.Security;

namespace RemoteCamp.Portal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ApplicationControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<ActionResult<Profile>> Get()
        {
            var email = User.Claims.GetEmail();
            var response = await _profileService.GetAsync(email);

            return CreateResponse(response);
        }

        [HttpGet("{email}")]
        [Authorize(Policy = Policies.Admin)]
        public async Task<ActionResult<Profile>> Get(string email)
        {
            var response = await _profileService.GetAsync(email);

            return CreateResponse(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post(IList<IFormFile> files, [FromForm]string profile)
        {
            var profileObject = CreateProfileObject(files, profile);
            var response = await _profileService.UpdateAsync(profileObject);
            return CreateResponse(response);
        }

        private static ProfileUpdateRequest CreateProfileObject(IList<IFormFile> files, string profile)
        {
            var profileObject = JsonConvert.DeserializeObject<ProfileUpdateRequest>(profile);
            if (files.Count > 0)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            profileObject.UploadAttachmentInfo.Add(new UploadAttachmentInfo(file.FileName, fileBytes));
                        }
                    }
                }
            }

            return profileObject;
        }
    }
}
