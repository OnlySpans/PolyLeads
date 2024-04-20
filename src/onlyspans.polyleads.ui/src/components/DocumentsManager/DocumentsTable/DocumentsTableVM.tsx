import { injectable } from 'inversify';
import { makeObservable } from 'mobx';
import { IDocument } from '@/data/IDocument';
import { ColumnDef } from '@tanstack/react-table';

export interface IDocumentsTableVM {
  files: IDocument[];
}

@injectable()
class DocumentsTableVM implements IDocumentsTableVM {
  constructor() {
    makeObservable(this);
  }



  columns: ColumnDef<IDocument>[] = [
    {
      accessorKey: 'name',
      header: 'Название',
      cell: ({ row }) => (
        <div>{row.getValue('name')}</div>
      ),
    },
    {
      accessorKey: 'createdAt',
      header: 'Время добавления',
      cell: ({ row }) => (
        <div>{row.getValue('createdAt')}</div>
      ),
    },
    {
      accessorKey: 'RecognitionStatus',
      header: 'Статус распознавания',
      cell: ({ row }) => (
        <div>{row.getValue('RecognitionStatus')}</div>
      ),
    },
    {
      accessorKey: 'resource',
      header: 'Ресурс',
      cell: ({ row }) => (
        <div>{row.getValue('resource')}</div>
      ),
    },
    {
      accessorKey: 'createdBy',
      header: 'Пользователь',
      cell: ({ row }) => (
        <div>{row.getValue('createdBy')}</div>
      ),
    },
  ];

  files = [
    {
      name: 'Luxurious Steel Chair',
      createdAt: '1995-08-22T22:47:55.552Z',
      fileRecognitionStatus: 4,
      resource: 'Сайт Политеха',
      createdBy: 'Alysha',
    },
    {
      name: 'Recycled Concrete Bike',
      createdAt: '1993-03-21T17:23:23.207Z',
      fileRecognitionStatus: 3,
      resource: 'Телеграм',
      createdBy: 'Kaylah',
    },
    {
      name: 'Electronic Concrete Cheese',
      createdAt: '2006-10-13T14:46:05.818Z',
      fileRecognitionStatus: 2,
      resource: 'Сайт Политеха',
      createdBy: 'Zoe',
    },
    {
      name: 'Refined Plastic Pizza',
      createdAt: '2013-10-07T01:44:43.285Z',
      fileRecognitionStatus: 1,
      resource: 'Сайт Политеха',
      createdBy: 'Ryley',
    },
    {
      name: 'Refined Cotton Gloves',
      createdAt: '1987-08-31T15:49:22.344Z',
      fileRecognitionStatus: 0,
      resource: 'Телеграм',
      createdBy: 'Lilian',
    },
  ];
}

export default DocumentsTableVM;
