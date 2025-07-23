using FitFolio.Api.Client.Models.Workout;
using System.Net.Http.Json;

namespace FitFolio.Api.Client.Workout
{
    public class WorkoutApiClient
    {
        private readonly HttpClient _httpClient;

        public WorkoutApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task StartAsync(WorkoutStartRequestBody request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/workout/start", request);
            response.EnsureSuccessStatusCode();
        }

        public async Task StopAsync(Guid workoutId)
        {
            var response = await _httpClient.PostAsync($"api/workout/stop?id={workoutId}", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task AddDetailAsync(AddWorkoutDetailRequestBody request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/workout/add-detail", request);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateCommentAsync(UpdateCommentRequestBody request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/workout/update-comment", request);
            response.EnsureSuccessStatusCode();
        }
    }
}
