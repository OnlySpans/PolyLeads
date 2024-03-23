import { Container } from 'inversify';
import React from 'react';

export const createDependencyContainer = (): Container => {
  const container = new Container();

  //container.bind<IFileService>(ServiceSymbols.IFileService).to(FileService);

  return container;
};

const DependencyContainer = React.createContext<Container>({} as Container);

export default DependencyContainer;