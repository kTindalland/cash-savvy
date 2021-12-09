FROM nginx:alpine
WORKDIR /usr/share/nginx/
RUN rm -rf ./*
COPY ./CashSavvy/publish/wwwroot ./blazor
COPY blazor.conf /etc/nginx/conf.d/default.conf
RUN sh -c "cd /usr/share/nginx/blazor; chown -R nginx:nginx *;"
ENTRYPOINT ["nginx", "-g", "daemon off;"]
