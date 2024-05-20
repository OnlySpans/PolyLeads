export default class Endpoints {
  public static baseApiUrl: string

  public static readonly suffix = 'api';

  public static readonly v1 = 'v1';

  public static readonly Auth = class {
    public static readonly base = (): string =>
      `${Endpoints.suffix}/${Endpoints.v1}/auth`;

    // @method post
    public static readonly signIn = (): string =>
      `${Endpoints.Auth.base()}/signin`;

    // @method post
    public static readonly signUp = (): string =>
      `${Endpoints.Auth.base()}/signup`;
  }
  
  public static readonly Role = class {
    public static readonly base = (): string =>
        `${Endpoints.suffix}/${Endpoints.v1}/role`;

    // @method get
    public static readonly getUserRole = (): string =>
        `${Endpoints.Role.base()}/current-user`;
  }

  public static readonly Document = class {
    public static readonly base = (): string =>
      `${Endpoints.suffix}/${Endpoints.v1}/document`;

    // @method get
    public static readonly query = (searchTerm: string | null): string =>
      searchTerm === null
        ? Endpoints.Document.base()
        : `${Endpoints.Document.base()}?q=${searchTerm}`

    // @method post
    public static readonly create = (): string =>
      Endpoints.Document.base();

    // @method get
    public static readonly getDetailed = (documentId: number): string =>
      `${Endpoints.Document.base()}/${documentId}`;

    // @method put
    public static readonly edit = (documentId: number): string =>
      `${Endpoints.Document.base()}/${documentId}`;

    // @method delete
    public static readonly delete = (documentId: number): string =>
      `${Endpoints.Document.base()}/${documentId}`;
  }
}
