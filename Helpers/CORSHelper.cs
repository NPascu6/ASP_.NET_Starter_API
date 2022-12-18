namespace ASP_CORE_BASIC_NET_6_API.Helpers
{
    public static class CORSHelper
    {
      
        public static void Configure(WebApplicationBuilder builder, string _MyAllowSpecificOrigins)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: _MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:3000",
                                                          "https://pascu.io")
                                      .AllowAnyHeader()
                                      .AllowCredentials()
                                      .AllowAnyMethod();
                                  });
            });
        }
    }
}
