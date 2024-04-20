import { injectable } from 'inversify';
import { makeObservable } from 'mobx';
import { IDocument } from '@/data/IDocument';

export interface IDocumentsTableVM {
  files: IDocument[];
}

@injectable()
class DocumentsTableVM implements IDocumentsTableVM {
  constructor() {

    makeObservable(this);
  }

  files = [
    {
      name: 'Recycled Cotton Chair',
      createdAt: '2012-03-17T06:24:54.696Z',
      fileRecognitionStatus: 'В очереди',
      resource: 'Сайт Политеха',
      createdBy: 'Vladimir',
    },
    {
      name: 'Small Metal Chicken',
      createdAt: '1990-10-27T02:44:46.794Z',
      fileRecognitionStatus: 'В очереди',
      resource: 'Сайт Политеха',
      createdBy: 'Wendell',
    },
    {
      name: 'Practical Steel Bacon',
      createdAt: '1980-03-24T19:18:36.868Z',
      fileRecognitionStatus: 'Ошибка',
      resource: 'Сосед',
      createdBy: 'Koby',
    },
    {
      name: 'Handmade Wooden Ball',
      createdAt: '1980-12-28T08:36:43.043Z',
      fileRecognitionStatus: 'В очереди',
      resource: 'Сайт Политеха',
      createdBy: 'Cristobal',
    },
    {
      name: 'Luxurious Granite Gloves',
      createdAt: '2003-03-19T16:44:07.429Z',
      fileRecognitionStatus: 'Ошибка',
      resource: 'Сайт Политеха',
      createdBy: 'Jules',
    },
    {
      name: 'Bespoke Frozen Hat',
      createdAt: '1988-12-05T12:19:34.529Z',
      fileRecognitionStatus: 'В очереди',
      resource: 'Сосед',
      createdBy: 'Vince',
    },
    {
      name: 'Incredible Bronze Chicken',
      createdAt: '2023-08-18T09:36:26.538Z',
      fileRecognitionStatus: 'Распознано',
      resource: 'Сосед',
      createdBy: 'Joseph',
    },
    {
      name: 'Recycled Granite Gloves',
      createdAt: '2022-09-22T07:18:23.864Z',
      fileRecognitionStatus: 'Распознано',
      resource: 'Сайт Политеха',
      createdBy: 'Jefferey',
    },
    {
      name: 'Recycled Concrete Car',
      createdAt: '1996-05-10T05:48:16.100Z',
      fileRecognitionStatus: 'Ошибка',
      resource: 'Сосед',
      createdBy: 'Lisandro',
    },
    {
      name: 'Sleek Cotton Fish',
      createdAt: '2011-04-26T01:57:32.336Z',
      fileRecognitionStatus: 'Распознано',
      resource: 'Сосед',
      createdBy: 'Monique',
    },
    {
      name: 'Sleek Granite Soap',
      createdAt: '2015-03-10T17:50:44.496Z',
      fileRecognitionStatus: 'В очереди',
      resource: 'Сайт Политеха',
      createdBy: 'Winnifred',
    },
    {
      name: 'Luxurious Steel Chair',
      createdAt: '1995-08-22T22:47:55.552Z',
      fileRecognitionStatus: 'Распознано',
      resource: 'Сайт Политеха',
      createdBy: 'Alysha',
    },
    {
      name: 'Recycled Concrete Bike',
      createdAt: '1993-03-21T17:23:23.207Z',
      fileRecognitionStatus: 'Ошибка',
      resource: 'Телеграм',
      createdBy: 'Kaylah',
    },
    {
      name: 'Electronic Concrete Cheese',
      createdAt: '2006-10-13T14:46:05.818Z',
      fileRecognitionStatus: 'Ошибка',
      resource: 'Сайт Политеха',
      createdBy: 'Zoe',
    },
    {
      name: 'Refined Plastic Pizza',
      createdAt: '2013-10-07T01:44:43.285Z',
      fileRecognitionStatus: 'В очереди',
      resource: 'Сайт Политеха',
      createdBy: 'Ryley',
    },
    {
      name: 'Refined Cotton Gloves',
      createdAt: '1987-08-31T15:49:22.344Z',
      fileRecognitionStatus: 'Распознано',
      resource: 'Телеграм',
      createdBy: 'Lilian',
    },
  ];
}

export default DocumentsTableVM;