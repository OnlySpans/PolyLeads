'use client';

import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
} from '@/components/ui/table';
import useGet from '@/hooks/useGet';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { IDocumentsTableVM } from '@/components/DocumentsTable/DocumentsTableVM';
import React from 'react';
import { observer } from 'mobx-react-lite';

interface IDocumentsTableProps {}
const DocumentsTable: React.FC<IDocumentsTableProps>  = () => {
  const vm = useGet<IDocumentsTableVM>(ServiceSymbols.IDocumentsTableVM);

  const documents = vm.files;

  return (
    <Table>
      <TableRow>
        <TableHead>Название</TableHead>
        <TableHead>Время добавления</TableHead>
        <TableHead>Статус распознавания</TableHead>
        <TableHead>Ресурс</TableHead>
        <TableHead>Пользователь</TableHead>
      </TableRow>
      <TableBody>
        {documents.map((document) => (
          <TableRow key={document.name}>
            <TableCell>{document.name}</TableCell>
            <TableCell>{document.createdAt}</TableCell>
            <TableCell>{document.fileRecognitionStatus}</TableCell>
            <TableCell>{document.resource}</TableCell>
            <TableCell>{document.createdBy}</TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>
  );
}

export default observer(DocumentsTable);