namespace TodoApi.Models;

public record TodoDto(
    int Id,
    string Title,
    bool IsDone
);

public record TodoCreateDto(
    string Title,
    bool IsDone
);

public record TodoUpdateDto(
    string Title,
    bool IsDone
);
