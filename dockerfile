FROM nginx:alpine
WORKDIR /usr/share/nginx/
RUN rm -rf ./*
COPY ./CashSavvy/publish/wwwroot ./html
COPY nginx.conf /etc/nginx/nginx.conf
ENTRYPOINT ["nginx", "-g", "daemon off;"]