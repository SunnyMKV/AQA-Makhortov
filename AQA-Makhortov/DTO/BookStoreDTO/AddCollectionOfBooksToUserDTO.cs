namespace AQA_Makhortov.DTO.BookStoreDTO;

public record AddCollectionOfBooksToUserDTO(
    string UserId,
    List<CollectionOfIsbnsDTO> Books);