﻿using BlazorBoilerplate.Shared.Dto.Email;
using BlazorBoilerplate.Shared.Interfaces;
using System;
using System.Threading.Tasks;

namespace BlazorBoilerplate.UI.Base.Pages.Admin.Settings
{
    public class EmailPage : SettingsBase
    {
        protected bool isSendEmailDialogOpen = false;
        protected EmailDto email { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            await LoadSettings("EmailConfiguration_");
        }

        protected async Task SendTestEmail()
        {
            try
            {
                var apiResponse = await apiClient.SendTestEmail(email);

                if (apiResponse.IsSuccessStatusCode)
                {
                    viewNotifier.Show(apiResponse.Message, ViewNotifierType.Success);
                }
                else
                {
                    viewNotifier.Show(apiResponse.Message + " : " + apiResponse.StatusCode, ViewNotifierType.Error, L["Operation Failed"]);
                }
            }
            catch (Exception ex)
            {
                viewNotifier.Show(ex.Message, ViewNotifierType.Error, L["Operation Failed"]);
            }
        }
    }
}
