using Client;
using ClientLibrary.Helpers;
using ClientLibrary.Services.Contracts;
using ClientLibrary.Services.Implemetations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using Syncfusion.Blazor.Popups;
using Syncfusion.Blazor;
using Client.ApplicationState;
using BaseLibrary.Entities;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NCaF5cXmZCeUxyWmFZfVpgdVRMY11bRHVPIiBoS35RckVlW3hcc3dURmNVU0Vz");
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NCaF5cXmZCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXhecnZUQmZcV0FzWUM=");
builder.Services.AddTransient<CustomHttpHandler>();
builder.Services.AddHttpClient("SystemApiClient", client =>
{
	client.BaseAddress = new Uri("https://localhost:7012/");
}).AddHttpMessageHandler<CustomHttpHandler>();
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7012/") });
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<GetHttpClient>();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();



//GENERAL DEPARTMENT, DEPARTMENT AND BRANCH
builder.Services.AddScoped<IGenericServiceInterface<GeneralDepartment>, GenericServiceImplementations<GeneralDepartment>>();
builder.Services.AddScoped<IGenericServiceInterface<Department>, GenericServiceImplementations<Department>>();
builder.Services.AddScoped<IGenericServiceInterface<Branch>, GenericServiceImplementations<Branch>>();

//COUNTRY, CITY AND TOWN
builder.Services.AddScoped<IGenericServiceInterface<Country>, GenericServiceImplementations<Country>>();
builder.Services.AddScoped<IGenericServiceInterface<City>, GenericServiceImplementations<City>>();
builder.Services.AddScoped<IGenericServiceInterface<Town>, GenericServiceImplementations<Town>>();
//OTHER PAGES
builder.Services.AddScoped<IGenericServiceInterface<Overtime>, GenericServiceImplementations<Overtime>>();
builder.Services.AddScoped<IGenericServiceInterface<OvertimeType>, GenericServiceImplementations<OvertimeType>>();
builder.Services.AddScoped<IGenericServiceInterface<Vacation>, GenericServiceImplementations<Vacation>>();
builder.Services.AddScoped<IGenericServiceInterface<VacationType>, GenericServiceImplementations<VacationType>>();
builder.Services.AddScoped<IGenericServiceInterface<Sanction>, GenericServiceImplementations<Sanction>>();
builder.Services.AddScoped<IGenericServiceInterface<SanctionType>, GenericServiceImplementations<SanctionType>>();


builder.Services.AddScoped<IGenericServiceInterface<Doctor>, GenericServiceImplementations<Doctor>>();

//EMPLOYEE
builder.Services.AddScoped<IGenericServiceInterface<Employee>, GenericServiceImplementations<Employee>>();


builder.Services.AddScoped<AllStates>();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<SfDialogService>();

await builder.Build().RunAsync();
