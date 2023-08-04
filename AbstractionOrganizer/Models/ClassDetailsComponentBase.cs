using AbstractionOrganizer.Services;
using Microsoft.AspNetCore.Components;

namespace AbstractionOrganizer.Models
{
    public class ClassDetailsComponentBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IClassModelService ClassModelService { get; set; }

        public ClassModel? classModel { get; set; }

        protected async override Task OnInitializedAsync()
        {
            classModel = await ClassModelService.GetClassModel(Id);
        }

    }
}
