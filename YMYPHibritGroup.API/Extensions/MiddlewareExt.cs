namespace YMYPHibrit3Group.API.Extensions
{
    public static class MiddlewareExt
    {
        public static void CheckWhiteIpAddressList(this WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                //check ip address
                var whiteIpList = new List<string>() { "127.0.0.1", "::1" };

                var requestIpAddress = context.Connection.RemoteIpAddress!.ToString();


                if (!whiteIpList.Contains(requestIpAddress))
                {
                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync("You are not authorized to access this resource");
                    return;
                }

                await next();


                //if (!whiteIpList.Contains(requestIpAddress))
                //{
                //    context.Response.StatusCode = 403;
                //    await context.Response.WriteAsync("You are not authorized to access this resource");
                //}
                //else
                //{
                //    await next();
                //}
            });
        }

        public static void ExampleMiddlewares(this WebApplication app)
        {
            #region Middleware example

            app.Use(async (context, next) =>
            {
                Console.WriteLine("1.middleware request");
                var request = context.Request;
                //request

                await next();
                Console.WriteLine("1.middleware response");

                var response = context.Response;
                //response
            });
            app.Use(async (context, next) =>
            {
                Console.WriteLine("2.middleware request");
                var request = context.Request;
                //request

                await next();
                Console.WriteLine("2.middleware response");

                var response = context.Response;
                //response
            });

            app.Map("/GetLoggingList", (app) =>
            {
                app.Run(async (context) =>
                {
                    Console.WriteLine("terminal middleware");

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "LoggingList.txt");
                    var logs = System.IO.File.ReadAllLines(path);

                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsJsonAsync(logs);
                });


                //app.Use(async (context, next) =>
                //{
                //    Console.WriteLine("3.middleware request");
                //    var request = context.Request;
                //    //request

                //    await next();
                //    Console.WriteLine("3.middleware response");

                //    var response = context.Response;
                //    //response
                //});

                //app.Run(async (context) =>
                //{
                //    Console.WriteLine("terminal middleware");


                //    context.Response.StatusCode = 200;
                //    await context.Response.WriteAsync("Terminal Middleware");

                //    //context.Response.WriteAsJsonAsync(new { data = new List<string>() { "ahmet", "" } });
                //});
            });

            #endregion
        }


        public static void AddCommonMiddleware(this WebApplication app)
        {
            //app.ExampleMiddlewares();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.CheckWhiteIpAddressList();


            app.UseHttpsRedirection();

            app.UseAuthorization();
        }
    }
}