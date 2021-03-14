public interface ICorrectRegistr
{
    bool CheckUsernameRegistr();
    bool CheckEmailRegistr();
    bool CheckPasswordRegistr();
    bool CheckRepeatPasswordRegistr();
    bool IsAllRegistrFieldsReady();
}
