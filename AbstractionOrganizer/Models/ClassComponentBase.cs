using AbstractionOrganizer.Services;
using Microsoft.AspNetCore.Components;

namespace AbstractionOrganizer.Models
{
	public class ClassComponentBase : ComponentBase
	{
        [Inject]
        public IClassModelService ClassModelService { get; set; }

        public IEnumerable<ClassModel> classes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            classes = (await ClassModelService.GetClassModels()).ToList();
        }
    }
}
