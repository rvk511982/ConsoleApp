namespace GraphQL.JWTAuthentication.Pagination.FileUpload.WebApi.Mutations
{
    public class FileUploadMutation
    {
        public async Task<string> UploadFile(IFile file)
        {
            var filePath = System.IO.Path.Combine("Uploads", file.Name);
            using var stream = new FileStream(filePath, FileMode.Create);
            await file.OpenReadStream().CopyToAsync(stream);
            return $"File uploaded: {filePath}";
        }
    }
}
