using System;
using Octokit;

namespace RemoteCamp.Portal.Core.Test.Common
{
    public class PullRequestReviewCommentBuilder
    {
        public string Body { get; set; }

        public PullRequestReviewComment Build()
        {
            return new PullRequestReviewComment(
                url: "https://github.com/org1/repo1/pull/6",
                id: 1234,
                nodeId: "node1",
                diffHunk: "diffHunk1",
                path: "path1",
                position: 1,
                originalPosition: 1,
                commitId: "commitid1",
                originalCommitId: "originalCommit1",
                user: null,
                body: Body,
                createdAt: DateTimeOffset.UtcNow,
                updatedAt: DateTimeOffset.UtcNow,
                htmlUrl: "https://github.com/org1/repo1/pull/6",
                pullRequestUrl: "pullRequestUrl",
                reactions: null,
                inReplyToId: null,
                pullRequestReviewId: null
                );

        }
    }
}
