namespace SignalRDemo.Hubs
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.SignalR;

    using SharedLibrary;

    public class CoffeeHub : Hub
    {
        private readonly IOrderService orderService;

        public CoffeeHub(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task GetUpdateForOrder(int orderId)
        {
            //await this.Clients.Groups("").SendAsync("");
            //await this.Groups.AddToGroupAsync("", "G");
            //this.Context.User.Identity.Name
            //this.Clients.Client("");

            CheckResult result;
            do
            {
                result = this.orderService.GetUpdate(orderId);
                if (result.New)
                {
                    await this.Clients.Caller.SendAsync("ReceiveOrderUpdate", result.Update);
                }
            }
            while (!result.Finished);
            await this.Clients.Caller.SendAsync("Finished");
        }

        //public override async Task OnConnectedAsync()
        //{
        //    await this.Clients.All.SendAsync("");
        //}

        //public override Task OnDisconnectedAsync(Exception exception)
        //{
        //    return base.OnDisconnectedAsync(exception);
        //}
    }
}
