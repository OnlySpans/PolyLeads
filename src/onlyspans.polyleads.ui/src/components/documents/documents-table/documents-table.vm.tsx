import { inject, injectable } from 'inversify';
import { action, computed, flow, makeObservable, observable } from 'mobx';
import { IDocument } from '@/data/abstractions/IDocument';
import { ColumnDef } from '@tanstack/react-table';
import React, { ReactElement } from 'react';
import { Checkbox } from '@/components/ui/checkbox';
import { Button } from '@/components/ui/button';
import { ChevronsUpDown, Ellipsis } from 'lucide-react';
import moment from 'moment';
import { Badge } from '@/components/ui/badge';
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from '@/components/ui/dropdown-menu';
import { FileRecognitionStatus } from '@/data/enum/fileRecognitionStatus';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import type { IDocumentApi } from '@/services/api/document/documentApi';
import DocumentEditingModal from '@/components/documents/edit-document-modal/edit-document-modal';

export interface IDocumentsTableVM {
  loadDocuments: () => void;
  documents: IDocument[];
  searchQuery: string;
  search: (text: string) => void;
  get columns(): ColumnDef<IDocument>[];
}

@injectable()
class DocumentsTableVM implements IDocumentsTableVM {
  @observable
  public documents: IDocument[] = [];

  @observable
  public isLoading: boolean = false;

  @observable
  public searchQuery: string = '';

  private readonly api: IDocumentApi;
  
  constructor(@inject(ServiceSymbols.IDocumentApi) api: IDocumentApi) {
    this.api = api;
    this.loadDocuments();
    makeObservable(this);
  }
  
  @action
  public setIsLoading = (isLoading: boolean) => {
    this.isLoading = isLoading;
  };

  @action
  public search = (text: string) => {
    this.searchQuery = text;
    this.loadDocuments();
  };
  
  @action.bound
  public loadDocuments = flow(function *(this: DocumentsTableVM) {
    try {
      this.setIsLoading(true);
      this.documents = yield this.api.query(this.searchQuery);
    } catch {
      this.documents = [];
    } finally {
      this.setIsLoading(false);
    }
  });

  private getFileRecognitionStatusBadge = (recognitionStatus: number): ReactElement => {
    switch (recognitionStatus) {
      case FileRecognitionStatus.Queued:
        return <Badge variant='queued'>В очереди</Badge>;
      case FileRecognitionStatus.Processing:
        return <Badge variant='processing'>Выполняется</Badge>;
      case FileRecognitionStatus.Success:
        return <Badge variant='success'>Текст распознан</Badge>;
      case FileRecognitionStatus.Error:
        return <Badge variant='error'>Ошибка распознования</Badge>;
      default:
        return <Badge variant='unknown'>Неизвестен</Badge>;
    }
  };

  @computed
  get columns(): ColumnDef<IDocument>[] {
    return [
      {
        id: 'select',
        header: ({ table }) => (
          <Checkbox
            checked={
              table.getIsAllPageRowsSelected() ||
              (table.getIsSomePageRowsSelected() && 'indeterminate')
            }
            onCheckedChange={(value) =>
              table.toggleAllPageRowsSelected(!!value)
            }
            aria-label='Select all'
          />
        ),
        cell: ({ row }) => (
          <Checkbox
            checked={row.getIsSelected()}
            onCheckedChange={(value) => row.toggleSelected(!!value)}
            aria-label='Select row'
          />
        ),
        enableSorting: false,
        enableHiding: false,
      },

      {
        accessorKey: 'name',
        header: ({ column }) => {
          return (
            <Button
              variant='ghost'
              className='m-[-1rem]'
              onClick={() =>
                column.toggleSorting(column.getIsSorted() === 'asc')
              }
            >
              Название
              <ChevronsUpDown className='ml-2 h-4 w-4' />
            </Button>
          );
        },
        cell: ({ row }) => row.getValue('name'),
        enableHiding: false,
      },
      {
        accessorKey: 'createdAt',
        meta: {
          name: 'Время добавления',
        },
        header: ({ column }) => {
          return (
            <Button
              variant='ghost'
              className='m-[-1rem]'
              onClick={() =>
                column.toggleSorting(column.getIsSorted() === 'asc')
              }
            >
              Время добавления
              <ChevronsUpDown className='ml-2 h-4 w-4' />
            </Button>
          );
        },

        cell: ({ row }) => (
          <>
            <Badge variant='secondary' className='mr-2'>
              {moment(row.getValue('createdAt')).format('HH:mm')}
            </Badge>
            <Badge variant='secondary'>
              {moment(row.getValue('createdAt')).format('DD.MM.YYYY')}
            </Badge>
          </>
        ),
      },
      {
        accessorKey: 'fileRecognitionStatus',
        meta: {
          name: 'Статус распознавания',
        },
        header: ({ column }) => {
          return (
            <Button
              variant='ghost'
              className='m-[-1rem]'
              onClick={() =>
                column.toggleSorting(column.getIsSorted() === 'asc')
              }
            >
              Статус распознавания
              <ChevronsUpDown className='ml-2 h-4 w-4' />
            </Button>
          );
        },
        cell: ({ row }) =>
          this.getFileRecognitionStatusBadge(
            row.getValue('fileRecognitionStatus'),
          ),
      },
      {
        accessorKey: 'resource',
        meta: {
          name: 'Ресурс',
        },
        header: ({ column }) => {
          return (
            <Button
              variant='ghost'
              className='m-[-1rem]'
              onClick={() =>
                column.toggleSorting(column.getIsSorted() === 'asc')
              }
            >
              Ресурс
              <ChevronsUpDown className='ml-2 h-4 w-4' />
            </Button>
          );
        },
        cell: ({ row }) => row.getValue('resource'),
      },
      {
        accessorKey: 'createdBy',
        meta: {
          name: 'Пользователь',
        },
        header: 'Пользователь',
        cell: ({ row }) => row.getValue('createdBy'),
      },
      {
        id: 'actions',
        enableHiding: false,
        cell: ({ row }) => {
          const document = row.original;

          return (
            <DropdownMenu>
              <DropdownMenuTrigger asChild>
                <Button variant='ghost' className='h-6 w-6 p-0 m-0'>
                  <Ellipsis className='h-4 w-4' />
                </Button>
              </DropdownMenuTrigger>
              <DropdownMenuContent align='end'>
                <DropdownMenuItem
                    onClick={() => window.open(document.downloadUrl, '_blank', 'noopener,noreferrer')}
                >
                  Открыть документ
                </DropdownMenuItem>
                <DropdownMenuItem
                  onClick={() => navigator.clipboard.writeText(document.name)}
                >
                  Копировать название
                </DropdownMenuItem>
                <DropdownMenuSeparator />
                <DocumentEditingModal document={document}/>
              </DropdownMenuContent>
            </DropdownMenu>
          );
        },
      },
    ];
  }
}

export default DocumentsTableVM;
