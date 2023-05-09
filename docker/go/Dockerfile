FROM golang:alpine AS builder
RUN apk update && apk add --no-cache git
WORKDIR $GOPATH/src/app/
COPY . .
RUN go get -d -v
RUN go build -o /go/bin/exercise

FROM scratch
COPY --from=builder /go/bin/exercise /go/bin/exercise
ENTRYPOINT ["/go/bin/exercise"]