export default class Endpoints {
  public static baseApiUrl: string

  public static readonly suffix = 'api';

  public static readonly v1 = 'v1';

  public static readonly Auth = class {
    public static readonly base = (): string =>
      `${Endpoints.suffix}/${Endpoints.v1}/auth`;

    public static readonly signin = (): string =>
      `${Endpoints.Auth.base()}/signin`;

    public static readonly signup = (): string =>
      `${Endpoints.Auth.base()}/signup`;
  }
}
