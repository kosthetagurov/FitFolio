using FitFolio.Api.Client.Models.Workout;
using System.Net.Http.Json;

namespace FitFolio.Api.Client.Workout
{
    public class WorkoutApiClient : ApiClientBase
    {
        public WorkoutApiClient(IHttpClientFactory httpClientFactory, Uri baseUri) 
            : base(httpClientFactory, baseUri)
        {         
        }

        public async Task<Data.Models.Workout> StartAsync(WorkoutStartRequestBody request)
        {
            using var httpClient = CreateClient();
            var response = await httpClient.PostAsJsonAsync("api/workout/start", request);
            response.EnsureSuccessStatusCode();

            var json = await ResponseAsStringAsync(response);
            return ResponseStringAsType<Data.Models.Workout>(json);
        }

        public async Task StopAsync(Guid workoutId)
        {
            using var httpClient = CreateClient();
            var response = await httpClient.PostAsync($"api/workout/stop?id={workoutId}", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task AddDetailAsync(AddWorkoutDetailRequestBody request)
        {
            using var httpClient = CreateClient();
            var response = await httpClient.PostAsJsonAsync("api/workout/add-detail", request);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateCommentAsync(UpdateCommentRequestBody request)
        {
            using var httpClient = CreateClient();
            var response = await httpClient.PostAsJsonAsync("api/workout/update-comment", request);
            response.EnsureSuccessStatusCode();
        }
    }
}
