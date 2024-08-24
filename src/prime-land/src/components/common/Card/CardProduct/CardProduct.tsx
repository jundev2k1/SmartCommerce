// Copyright (c) 2024 - Jun Dev. All rights reserved

import SquareFootOutlinedIcon from '@mui/icons-material/SquareFootOutlined';
import { Card, CardProps, Divider, Stack, Typography } from '@mui/material';

import { IProduct } from '../../../../models';
import { GetProductImage } from '../../../../utils';
import { CardBody, CardFooter, CardThumbnail } from '../Common';

interface CardProductProps extends CardProps {
  children: React.ReactNode;
  data: IProduct;
}

const CardProductComponent = ({
  children,
  data,
  ...props
}: CardProductProps) => {
  return (
    <Card {...props}>
      <CardThumbnail
        src={GetProductImage(data.images)[0]}
        sx={{ borderRadius: 2 }}
      />
      <CardBody>{children}</CardBody>
      <CardFooter padding=".875rem">
        <Divider />
        <Stack
          marginTop=".25rem"
          direction="row"
          spacing={2}
          alignItems="center"
        >
          <Stack direction="row" spacing={1}>
            <SquareFootOutlinedIcon />
            <Typography variant="body1">{data.size3}</Typography>
          </Stack>
        </Stack>
      </CardFooter>
    </Card>
  );
};

export default CardProductComponent;
