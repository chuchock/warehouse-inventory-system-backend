using System.Collections.Generic;
using Xunit;

namespace wisys.tests
{
	public class WarehouseService
	{
		private readonly WarehouseController _warehouseController;

		[Fact]
		public void GetTest_ReturnsListOfWarehouses()
		{
			//arrange
			var mockPosts = new List<Post> {
				new Post{Title = "Tdd One"},
				new Post{Title = "Tdd and Bdd"}
			};

			_mockPostsList.Object.AddRange(mockPosts);

			//act
			var result = WarehouseController.Get();

			//assert
			var model = Assert.IsAssignableFrom<ActionResult<List<Post>>>(result);
			Assert.Equal(2, model.Value.Count);
		}
	}
}
