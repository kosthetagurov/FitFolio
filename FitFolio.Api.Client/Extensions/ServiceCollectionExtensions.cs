using FitFolio.Api.Client.Exercise;
using FitFolio.Api.Client.ExerciseCategory;
using FitFolio.Api.Client.Workout;
using Microsoft.Extensions.DependencyInjection;

namespace FitFolio.Api.Client.Extensions
{
    /// <summary>
    /// Extension methods for configuring API clients in the dependency injection container.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the Workout API client to the service collection using the standard AddHttpClient pattern.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="baseAddress">The base address of the API.</param>
        /// <param name="configureHttpClient">Optional action to configure the HTTP client.</param>
        /// <returns>An IHttpClientBuilder that can be used to configure the HttpClient.</returns>
        /// <example>
        /// Basic usage:
        /// <code>
        /// services.AddWorkoutApiClient("https://api.fitfolio.com");
        /// </code>
        /// 
        /// With custom configuration:
        /// <code>
        /// services.AddWorkoutApiClient("https://api.fitfolio.com", client =>
        /// {
        ///     client.Timeout = TimeSpan.FromSeconds(60);
        ///     client.DefaultRequestHeaders.Add("X-Custom-Header", "value");
        /// });
        /// </code>
        /// 
        /// With Polly resilience policies:
        /// <code>
        /// services.AddWorkoutApiClient("https://api.fitfolio.com")
        ///     .AddTransientHttpErrorPolicy(policy => 
        ///         policy.WaitAndRetryAsync(3, retryAttempt => 
        ///             TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))))
        ///     .AddTransientHttpErrorPolicy(policy => 
        ///         policy.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));
        /// </code>
        /// </example>
        public static IHttpClientBuilder AddWorkoutApiClient(
            this IServiceCollection services,
            string baseAddress,
            Action<HttpClient>? configureHttpClient = null)
        {
            if (string.IsNullOrWhiteSpace(baseAddress))
            {
                throw new ArgumentException("Base address cannot be null or empty.", nameof(baseAddress));
            }

            // Register the client using AddHttpClient - this is the standard .NET pattern
            return services.AddHttpClient<IWorkoutApiClient, WorkoutApiClient>(client =>
            {
                client.BaseAddress = new Uri(baseAddress);
                client.Timeout = TimeSpan.FromSeconds(30);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "FitFolio-ApiClient/1.0");

                // Allow custom configuration
                configureHttpClient?.Invoke(client);
            });
        }

        /// <summary>
        /// Adds the Workout API client with a named HttpClient configuration.
        /// This allows you to register multiple instances with different configurations.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="clientName">The logical name of the HttpClient to configure.</param>
        /// <param name="baseAddress">The base address of the API.</param>
        /// <param name="configureHttpClient">Optional action to configure the HTTP client.</param>
        /// <returns>An IHttpClientBuilder that can be used to configure the HttpClient.</returns>
        public static IHttpClientBuilder AddWorkoutApiClient(
            this IServiceCollection services,
            string clientName,
            string baseAddress,
            Action<HttpClient>? configureHttpClient = null)
        {
            if (string.IsNullOrWhiteSpace(clientName))
            {
                throw new ArgumentException("Client name cannot be null or empty.", nameof(clientName));
            }

            if (string.IsNullOrWhiteSpace(baseAddress))
            {
                throw new ArgumentException("Base address cannot be null or empty.", nameof(baseAddress));
            }

            return services.AddHttpClient<IWorkoutApiClient, WorkoutApiClient>(clientName, client =>
            {
                client.BaseAddress = new Uri(baseAddress);
                client.Timeout = TimeSpan.FromSeconds(30);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "FitFolio-ApiClient/1.0");

                configureHttpClient?.Invoke(client);
            });
        }

        /// <summary>
        /// Adds the Exercise API client to the service collection using the standard AddHttpClient pattern.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="baseAddress">The base address of the API.</param>
        /// <param name="configureHttpClient">Optional action to configure the HTTP client.</param>
        /// <returns>An IHttpClientBuilder that can be used to configure the HttpClient.</returns>
        public static IHttpClientBuilder AddExerciseApiClient(
            this IServiceCollection services,
            string baseAddress,
            Action<HttpClient>? configureHttpClient = null)
        {
            if (string.IsNullOrWhiteSpace(baseAddress))
            {
                throw new ArgumentException("Base address cannot be null or empty.", nameof(baseAddress));
            }

            return services.AddHttpClient<IExerciseApiClient, ExerciseApiClient>(client =>
            {
                client.BaseAddress = new Uri(baseAddress);
                client.Timeout = TimeSpan.FromSeconds(30);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "FitFolio-ApiClient/1.0");

                configureHttpClient?.Invoke(client);
            });
        }

        /// <summary>
        /// Adds the Exercise API client with a named HttpClient configuration.
        /// This allows you to register multiple instances with different configurations.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="clientName">The logical name of the HttpClient to configure.</param>
        /// <param name="baseAddress">The base address of the API.</param>
        /// <param name="configureHttpClient">Optional action to configure the HTTP client.</param>
        /// <returns>An IHttpClientBuilder that can be used to configure the HttpClient.</returns>
        public static IHttpClientBuilder AddExerciseApiClient(
            this IServiceCollection services,
            string clientName,
            string baseAddress,
            Action<HttpClient>? configureHttpClient = null)
        {
            if (string.IsNullOrWhiteSpace(clientName))
            {
                throw new ArgumentException("Client name cannot be null or empty.", nameof(clientName));
            }

            if (string.IsNullOrWhiteSpace(baseAddress))
            {
                throw new ArgumentException("Base address cannot be null or empty.", nameof(baseAddress));
            }

            return services.AddHttpClient<IExerciseApiClient, ExerciseApiClient>(clientName, client =>
            {
                client.BaseAddress = new Uri(baseAddress);
                client.Timeout = TimeSpan.FromSeconds(30);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "FitFolio-ApiClient/1.0");

                configureHttpClient?.Invoke(client);
            });
        }

        /// <summary>
        /// Adds the Exercise Category API client to the service collection using the standard AddHttpClient pattern.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="baseAddress">The base address of the API.</param>
        /// <param name="configureHttpClient">Optional action to configure the HTTP client.</param>
        /// <returns>An IHttpClientBuilder that can be used to configure the HttpClient.</returns>
        public static IHttpClientBuilder AddExerciseCategoryApiClient(
            this IServiceCollection services,
            string baseAddress,
            Action<HttpClient>? configureHttpClient = null)
        {
            if (string.IsNullOrWhiteSpace(baseAddress))
            {
                throw new ArgumentException("Base address cannot be null or empty.", nameof(baseAddress));
            }

            return services.AddHttpClient<IExerciseCategoryApiClient, ExerciseCategoryApiClient>(client =>
            {
                client.BaseAddress = new Uri(baseAddress);
                client.Timeout = TimeSpan.FromSeconds(30);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "FitFolio-ApiClient/1.0");

                configureHttpClient?.Invoke(client);
            });
        }

        /// <summary>
        /// Adds the Exercise Category API client with a named HttpClient configuration.
        /// This allows you to register multiple instances with different configurations.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="clientName">The logical name of the HttpClient to configure.</param>
        /// <param name="baseAddress">The base address of the API.</param>
        /// <param name="configureHttpClient">Optional action to configure the HTTP client.</param>
        /// <returns>An IHttpClientBuilder that can be used to configure the HttpClient.</returns>
        public static IHttpClientBuilder AddExerciseCategoryApiClient(
            this IServiceCollection services,
            string clientName,
            string baseAddress,
            Action<HttpClient>? configureHttpClient = null)
        {
            if (string.IsNullOrWhiteSpace(clientName))
            {
                throw new ArgumentException("Client name cannot be null or empty.", nameof(clientName));
            }

            if (string.IsNullOrWhiteSpace(baseAddress))
            {
                throw new ArgumentException("Base address cannot be null or empty.", nameof(baseAddress));
            }

            return services.AddHttpClient<IExerciseCategoryApiClient, ExerciseCategoryApiClient>(clientName, client =>
            {
                client.BaseAddress = new Uri(baseAddress);
                client.Timeout = TimeSpan.FromSeconds(30);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "FitFolio-ApiClient/1.0");

                configureHttpClient?.Invoke(client);
            });
        }

        /// <summary>
        /// Adds all FitFolio API clients to the service collection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="baseAddress">The base address of the API.</param>
        /// <param name="configureHttpClient">Optional action to configure all HTTP clients.</param>
        /// <returns>The service collection for chaining.</returns>
        public static IServiceCollection AddFitFolioApiClients(
            this IServiceCollection services,
            string baseAddress,
            Action<HttpClient>? configureHttpClient = null)
        {
            services.AddWorkoutApiClient(baseAddress, configureHttpClient);
            services.AddExerciseApiClient(baseAddress, configureHttpClient);
            services.AddExerciseCategoryApiClient(baseAddress, configureHttpClient);

            return services;
        }
    }
}


